#include <string.h>
#include <assert.h>
#include <math.h>
#include <float.h>

#include "asn1crt.h"


byte masks[] = {0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01};
byte masksb[] = {0x0, 0x1, 0x3, 0x7, 0xF, 0x1F, 0x3F, 0x7F, 0xFF};

uint32 masks2[] = {0x0, 0xFF, 
						0xFF00, 
						0xFF0000, 
						0xFF000000
					};
#if WORD_SIZE==8
uint64 masks2b[] = {0x0, 0xFF, 
						0xFF00, 
						0xFF0000, 
						0xFF000000, 
						0xFF00000000ULL, 
						0xFF0000000000ULL, 
						0xFF000000000000ULL, 
						0xFF00000000000000ULL};
#endif

/***********************************************************************************************/
/*   Bit Stream Functions																	   */
/***********************************************************************************************/
void BitStream_AppendByte(BitStream* pBitStrm, byte v, flag negate);
int GetNumberOfBitsForNonNegativeInteger(uint v);



void BitStream_Init(BitStream* pBitStrm, byte* buf, long count) 
{
	pBitStrm->count = count;
	pBitStrm->buf = buf;
	memset(pBitStrm->buf,0x0,count);
	pBitStrm->currentByte = 0;
	pBitStrm->currentBit=0;	
}
void BitStream_AttachBuffer(BitStream* pBitStrm, unsigned char* buf, long count)
{
	pBitStrm->count = count;
	pBitStrm->buf = buf;
	pBitStrm->currentByte = 0;
	pBitStrm->currentBit=0;	
}

sint BitStream_GetLength(BitStream* pBitStrm)
{
	int ret = pBitStrm->currentByte;
	if (pBitStrm->currentBit)
		ret++;
	return ret;
}


void BitStream_AppendBitOne(BitStream* pBitStrm) 
{
	pBitStrm->buf[pBitStrm->currentByte] |= masks[pBitStrm->currentBit];

	if (pBitStrm->currentBit<7) 
		pBitStrm->currentBit++;
	else {
		pBitStrm->currentBit=0;
		pBitStrm->currentByte++;
	}
	assert(pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8);
}

void BitStream_AppendBitZero(BitStream* pBitStrm) 
{
	if (pBitStrm->currentBit<7) 
		pBitStrm->currentBit++;
	else {
		pBitStrm->currentBit=0;
		pBitStrm->currentByte++;
	}
	assert(pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8);
}

void BitStream_AppendNBitZero(BitStream* pBitStrm, int nbits) 
{
	int totalBits = pBitStrm->currentBit + nbits;
	pBitStrm->currentBit = totalBits % 8;
	pBitStrm->currentByte += totalBits / 8;
}

void BitStream_AppendNBitOne(BitStream* pBitStrm, int nbits) 
{
	int i;

	while(nbits>=8) {
		BitStream_AppendByte(pBitStrm, 0xFF, FALSE);
		nbits-=8;
	}
	for(i=0; i<nbits; i++)
		BitStream_AppendBitOne(pBitStrm);

}

void BitStream_AppendBit(BitStream* pBitStrm, flag v) 
{
	if (v) 
		pBitStrm->buf[pBitStrm->currentByte] |= masks[pBitStrm->currentBit];

	if (pBitStrm->currentBit<7) 
		pBitStrm->currentBit++;
	else {
		pBitStrm->currentBit=0;
		pBitStrm->currentByte++;
	}
	assert(pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8);
}


flag BitStream_ReadBit(BitStream* pBitStrm, flag* v) 
{
	*v = pBitStrm->buf[pBitStrm->currentByte] & masks[pBitStrm->currentBit];
	
	if (pBitStrm->currentBit<7) 
		pBitStrm->currentBit++;
	else {
		pBitStrm->currentBit=0;
		pBitStrm->currentByte++;
	}
	return pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8;
}

void BitStream_AppendByte(BitStream* pBitStrm, byte v, flag negate) 
{
	int cb = pBitStrm->currentBit;
	int ncb = 8 - pBitStrm->currentBit;
	if (negate)
		v=~v;
	pBitStrm->buf[pBitStrm->currentByte++] |=  v >> cb;

	assert(pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8);

	if (cb)
		pBitStrm->buf[pBitStrm->currentByte] |= v << ncb;

}



flag BitStream_ReadByte(BitStream* pBitStrm, byte* v) 
{
	int cb = pBitStrm->currentBit;
	int ncb = 8 - pBitStrm->currentBit;
	*v=	pBitStrm->buf[pBitStrm->currentByte++]  << cb;

	if (cb) {
		*v |= pBitStrm->buf[pBitStrm->currentByte] >> ncb;
	}

	return pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8;
}


/* nbits 1..7*/
void BitStream_AppendPartialByte(BitStream* pBitStrm, byte v, byte nbits, flag negate) 
{
	int cb = pBitStrm->currentBit;
	int totalBits = cb+nbits;
	int totalBitsForNextByte;
	if (negate)
		v=masksb[nbits]& (~v);

	if (totalBits<=8) {
		pBitStrm->buf[pBitStrm->currentByte] |=  v <<(8 -totalBits);
		pBitStrm->currentBit+=nbits;
		if (pBitStrm->currentBit==8) {
			pBitStrm->currentBit=0;
			pBitStrm->currentByte++;
		}
	} 
	else {
		totalBitsForNextByte = totalBits - 8;
		pBitStrm->buf[pBitStrm->currentByte++] |= v >> totalBitsForNextByte;
		pBitStrm->buf[pBitStrm->currentByte] |= v << (8 - totalBitsForNextByte);
		pBitStrm->currentBit = totalBitsForNextByte;
	}
	assert(pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8);

}

/* nbits 1..7*/
flag BitStream_ReadPartialByte(BitStream* pBitStrm, byte *v, byte nbits) 
{
	int cb = pBitStrm->currentBit;
	int totalBits = cb+nbits;
	int totalBitsForNextByte;

	if (totalBits<=8) {
		*v = (pBitStrm->buf[pBitStrm->currentByte] >> (8 -totalBits)) & masksb[nbits];
		pBitStrm->currentBit+=nbits;
		if (pBitStrm->currentBit==8) {
			pBitStrm->currentBit=0;
			pBitStrm->currentByte++;
		}
	} 
	else {
		totalBitsForNextByte = totalBits - 8;
		*v = pBitStrm->buf[pBitStrm->currentByte++] << totalBitsForNextByte;
		*v |= pBitStrm->buf[pBitStrm->currentByte] >> (8 - totalBitsForNextByte);
		*v &= masksb[nbits];
		pBitStrm->currentBit = totalBitsForNextByte;
	}
	return pBitStrm->currentByte*8+pBitStrm->currentBit<=pBitStrm->count*8;
}



/***********************************************************************************************/
/***********************************************************************************************/
/***********************************************************************************************/
/***********************************************************************************************/
/*   Integer Functions																	   */
/***********************************************************************************************/
/***********************************************************************************************/
/***********************************************************************************************/
/***********************************************************************************************/



void BitStream_EncodeNonNegativeInteger32Neg(BitStream* pBitStrm, uint32 v, flag negate) 
{
	int cc;
	uint32 curMask;
	int pbits;

	if (v==0)
		return;

	if (v<0x100) {
		cc = 8;
		curMask = 0x80;
	} else if (v<0x10000) {
		cc = 16;
		curMask = 0x8000;
	} else if (v<0x1000000) {
		cc = 24;
		curMask = 0x800000;
	} else {
		cc = 32;
		curMask = 0x80000000;
	}

/*	curMask = ((uint32)1) << (cc-1); */


	while( (v & curMask)==0 ) {
		curMask >>=1;
		cc--;
	}


	pbits = cc % 8;
	if (pbits) {
		cc-=pbits;
		BitStream_AppendPartialByte(pBitStrm,(byte)(v>>cc), pbits, negate);
	}

	while (cc) {
		uint32 t1 = v & masks2[cc>>3]; /* equiv to cc/8 */
		cc-=8;
		BitStream_AppendByte(pBitStrm, (byte)(t1 >>cc), negate);
	}

}

flag BitStream_DecodeNonNegativeInteger32Neg(BitStream* pBitStrm, uint32* v, int nBits) 
{
	byte b;
	*v = 0;
	while(nBits>=8) {
		*v<<=8;
		if (!BitStream_ReadByte(pBitStrm, &b))
			return FALSE;
		*v|= b;
		nBits -=8;
	}
	if (nBits) 
	{
		*v<<=nBits;
		if (!BitStream_ReadPartialByte(pBitStrm, &b, nBits))
			return FALSE;
		*v|=b;
	}

	return TRUE;
}



void BitStream_EncodeNonNegativeInteger(BitStream* pBitStrm, uint v) 
{

#if WORD_SIZE==8
	if (v<0x100000000LL)
		BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, (uint32)v, 0);
	else {
		uint32 hi = (uint32)(v>>32);
		uint32 lo = (uint32)v;
		int nBits;
		BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, hi, 0); 

		nBits = GetNumberOfBitsForNonNegativeInteger(lo);
		BitStream_AppendNBitZero(pBitStrm, 32-nBits);
		BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, lo, 0);
	}
#else
	BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, v, 0);
#endif
}


flag BitStream_DecodeNonNegativeInteger(BitStream* pBitStrm, uint* v, int nBits)
{
#if WORD_SIZE==8
		uint32 hi=0;
		uint32 lo=0;
		flag ret;

		if (nBits<=32)
		{
			ret = BitStream_DecodeNonNegativeInteger32Neg(pBitStrm, &lo, nBits);
			*v = lo;
			return ret;
		}

		ret = BitStream_DecodeNonNegativeInteger32Neg(pBitStrm, &hi, 32) && BitStream_DecodeNonNegativeInteger32Neg(pBitStrm, &lo, nBits-32);

		*v = hi;
		*v <<=nBits-32;
		 *v |= lo;
		return ret;
#else
	return BitStream_DecodeNonNegativeInteger32Neg(pBitStrm, v, nBits);
#endif
}


void BitStream_EncodeNonNegativeIntegerNeg(BitStream* pBitStrm, uint v, flag negate) 
{
#if WORD_SIZE==8
	if (v<0x100000000LL)
		BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, (uint32)v, negate);
	else {
		int nBits;
		uint32 hi = (uint32)(v>>32);
		uint32 lo = (uint32)v;
		BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, hi, negate);

		//bug !!!!
		if (negate)
			lo = ~lo;
		nBits = GetNumberOfBitsForNonNegativeInteger(lo);
		BitStream_AppendNBitZero(pBitStrm, 32-nBits);
		BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, lo, 0);
	}
#else
	BitStream_EncodeNonNegativeInteger32Neg(pBitStrm, v, negate);
#endif
}

int GetNumberOfBitsForNonNegativeInteger32(uint32 v) 
{
	int ret=0;

	if (v<0x100) {
		ret = 0;
	} else if (v<0x10000) {
		ret = 8;
		v >>= 8;
	} else if (v<0x1000000) {
		ret = 16;
		v >>= 16;
	} else {
		ret = 24;
		v >>= 24;
	}
	while( v>0 ) {
		v >>= 1;
		ret++;
	}
	return ret;
}

int GetNumberOfBitsForNonNegativeInteger(uint v) 
{
#if WORD_SIZE==8
	if (v<0x100000000LL)
		return GetNumberOfBitsForNonNegativeInteger32((uint32)v);
	else {
		uint32 hi = (uint32)(v>>32);
		return 32 + GetNumberOfBitsForNonNegativeInteger32(hi);
	}
#else
	return GetNumberOfBitsForNonNegativeInteger32(v);
#endif
}
/*
int GetNumberOfBitsForSignedNegativeInteger(sint v) 
{
    if (v >= 0)
        return GetNumberOfBitsForNonNegativeInteger((uint)v);

    return GetNumberOfBitsForNonNegativeInteger((sint)(-v - 1));
}
*/
int GetLengthInBytesOfUInt(uint v)
{
	int ret=0;
	uint32 v32 = (uint32)v;
#if WORD_SIZE==8
	if (v>0xFFFFFFFF) {
		ret = 4;
		v32 = (uint32)(v>>32);
	} 
#endif
	
	if (v32<0x100)
		return ret+1;
	if (v32<0x10000)
		return ret+2;
	if (v32<0x1000000)
		return ret+3;
    return ret+4;
}

int GetLengthSIntHelper(uint v)
{
	int ret=0;
	uint32 v32 = (uint32)v;
#if WORD_SIZE==8
	if (v>0x7FFFFFFF) {
		ret = 4;
		v32 = (uint32)(v>>32);
	} 
#endif

	if (v32<=0x7F)
		return ret+1;
	if (v32<=0x7FFF)
		return ret+2;
	if (v32<=0x7FFFFF)
		return ret+3;
    return ret+4;
}

int GetLengthInBytesOfSInt(sint v)
{
    if (v >= 0)
        return GetLengthSIntHelper((sint)v);

    return GetLengthSIntHelper((sint)(-v - 1));
}



/*
void BitStream_Encode2ndComplementInteger(BitStream* pBitStrm, sint v)
{
	if (v>=0) {
		BitStream_AppendBitZero(pBitStrm);
		BitStream_EncodeNonNegativeInteger(pBitStrm,v);
	} 
	else {
		BitStream_AppendBitOne(pBitStrm);
		BitStream_EncodeNonNegativeIntegerNeg(pBitStrm,-v-1, 1);
	}
}
flag BitStream_Decode2ndComplementInteger(BitStream* pBitStrm, sint* v)
{
	assert(0);
	return TRUE;
}
*/

 
void BitStream_EncodeConstraintWholeNumber(BitStream* pBitStrm, sint v, sint min, sint max)
{
	int nRangeBits;
	int nBits;
	uint range = max-min;
	assert(min<=max);
	if(!range)
		return;
    nRangeBits = GetNumberOfBitsForNonNegativeInteger(range);
	nBits = GetNumberOfBitsForNonNegativeInteger(v-min);
	BitStream_AppendNBitZero(pBitStrm, nRangeBits-nBits);
	BitStream_EncodeNonNegativeInteger(pBitStrm,v-min);
}



flag BitStream_DecodeConstraintWholeNumber(BitStream* pBitStrm, sint* v, sint min, sint max)
{
	uint uv;
	int nRangeBits;
	uint range = max-min;
	assert(min<=max);

	*v=0;
	if(!range)
		return TRUE;

    nRangeBits = GetNumberOfBitsForNonNegativeInteger(range);


	if (BitStream_DecodeNonNegativeInteger(pBitStrm, &uv, nRangeBits))
	{
		*v = uv+min;
		return TRUE;
	}
	return FALSE;
}


     
void BitStream_EncodeSemiConstraintWholeNumber(BitStream* pBitStrm, sint v, sint min)
{
	int nBytes = GetLengthInBytesOfUInt((uint)(v - min));
	
	/* encode length */
    BitStream_EncodeConstraintWholeNumber(pBitStrm, nBytes, 0, 255); /*8 bits, first bit is always 0*/
	/* put required zeros*/
	BitStream_AppendNBitZero(pBitStrm,nBytes*8-GetNumberOfBitsForNonNegativeInteger((uint)(v-min)));
	/*Encode number */
	BitStream_EncodeNonNegativeInteger(pBitStrm,v-min);
}


flag BitStream_DecodeSemiConstraintWholeNumber(BitStream* pBitStrm, sint* v, sint min)
{
	sint nBytes;
	int i;
	*v=0;
	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nBytes, 0, 255))
		return FALSE;
	for(i=0;i<nBytes;i++) {
		byte b=0;
		if (!BitStream_ReadByte(pBitStrm, &b))
			return FALSE;
		*v = (*v<<8) | b;
	}
	*v+=min;
	return TRUE;
}



void BitStream_EncodeUnConstraintWholeNumber(BitStream* pBitStrm, sint v)
{
	int nBytes = GetLengthInBytesOfSInt(v);
	
	/* encode length */
    BitStream_EncodeConstraintWholeNumber(pBitStrm, nBytes, 0, 255); /*8 bits, first bit is always 0*/

	if (v>=0) {
		BitStream_AppendNBitZero(pBitStrm,nBytes*8-GetNumberOfBitsForNonNegativeInteger((uint)v));
		BitStream_EncodeNonNegativeInteger(pBitStrm,v);
	}
	else {
		BitStream_AppendNBitOne(pBitStrm,nBytes*8-GetNumberOfBitsForNonNegativeInteger((uint)(-v-1)));
		BitStream_EncodeNonNegativeIntegerNeg(pBitStrm,-v-1, 1);
	}
}

flag BitStream_DecodeUnConstraintWholeNumber(BitStream* pBitStrm, sint* v)
{
	sint nBytes;
	int i;
	flag valIsNegative=FALSE;
	*v=0;
	

	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &nBytes, 0, 255))
		return FALSE;


	for(i=0;i<nBytes;i++) {
		byte b=0;
		if (!BitStream_ReadByte(pBitStrm, &b))
			return FALSE;
		if (!i) {
			valIsNegative = b>0x7F;
			if (valIsNegative)
				*v=-1;
		}
		*v = (*v<<8) | b;
	}
	return TRUE;
}



/*
            Bynary encoding will be used
            REAL = M*B^E
            where
            M = S*N*2^F

            ENCODING is done within three parts
            part 1 is 1 byte header
            part 2 is 1 or more byte for exponent
            part 3 is 3 or more byte for mantissa (N)

            First byte        
            S :0-->+, S:1-->-1
            Base will be always be 2 (implied by 6th and 5th bit which are zero)
            ab: F  (0..3)
            cd:00 --> 1 byte for exponent as 2's complement 
            cd:01 --> 2 byte for exponent as 2's complement 
            cd:10 --> 3 byte for exponent as 2's complement 
            cd:11 --> 1 byte for encoding the length of the exponent, then the expoent 

             8 7 6 5 4 3 2 1 
            +-+-+-+-+-+-+-+-+
            |1|S|0|0|a|b|c|d|
            +-+-+-+-+-+-+-+-+
*/


void BitStream_EncodeReal(BitStream* pBitStrm, double v)
{
	byte header=0x80;
	int nExpLen;
	int nManLen;
	int exp;
	uint mantissa;


	if (v==0.0) 
	{
		BitStream_EncodeConstraintWholeNumber(pBitStrm, 0, 0, 0xFF);
		return;
	}

	if (v==HUGE_VAL) 
	{
		BitStream_EncodeConstraintWholeNumber(pBitStrm, 1, 0, 0xFF);
		BitStream_EncodeConstraintWholeNumber(pBitStrm, 0x40, 0, 0xFF);
		return;
	}

	if (v==-HUGE_VAL)
	{
		BitStream_EncodeConstraintWholeNumber(pBitStrm, 1, 0, 0xFF);
		BitStream_EncodeConstraintWholeNumber(pBitStrm, 0x41, 0, 0xFF);
		return;
	}
	if (v < 0) {
        header |= 0x40;
		v=-v;
	}

	CalculateMantissaAndExponent(v, &exp, &mantissa);
	nExpLen = GetLengthInBytesOfSInt(exp);
	nManLen = GetLengthInBytesOfUInt(mantissa);
	assert(exp<=3);
    if (nExpLen == 2)
        header |= 1;
    else if (nExpLen == 3)
        header |= 2;


	/* encode length */
	BitStream_EncodeConstraintWholeNumber(pBitStrm, 1+nExpLen+nManLen, 0, 0xFF);

	/* encode header */
	BitStream_EncodeConstraintWholeNumber(pBitStrm, header, 0, 0xFF);

	/* encode exponent */
	if (exp>=0) {
		BitStream_AppendNBitZero(pBitStrm,nExpLen*8-GetNumberOfBitsForNonNegativeInteger((uint)exp));
		BitStream_EncodeNonNegativeInteger(pBitStrm,exp);
	}
	else {
		BitStream_AppendNBitOne(pBitStrm,nExpLen*8-GetNumberOfBitsForNonNegativeInteger((uint)(-exp-1)));
		BitStream_EncodeNonNegativeIntegerNeg(pBitStrm,-exp-1, 1);
	}


	/* encode mantissa */
	BitStream_AppendNBitZero(pBitStrm,nManLen*8-GetNumberOfBitsForNonNegativeInteger((uint)(mantissa)));
	BitStream_EncodeNonNegativeInteger(pBitStrm,mantissa);

}

flag DecodeRealAsBinaryEncoding(BitStream* pBitStrm, int length, byte header, double* v);
flag DecodeRealUsingDecimalEncoding(BitStream* pBitStrm, int length, byte header, double* v);

flag BitStream_DecodeReal(BitStream* pBitStrm, double* v)
{
	byte header;
	byte length;

	if (!BitStream_ReadByte(pBitStrm, &length))
		return FALSE;
	if (length == 0)
	{
		*v=0.0;
		return TRUE;
	}

	if (!BitStream_ReadByte(pBitStrm, &header))
		return FALSE;

	if (header==0x40)
	{
		*v = HUGE_VAL;
		return TRUE;
	}

	if (header==0x41)
	{
		*v = -HUGE_VAL;
		return TRUE;
	}
	if (header & 0x80) 
		return DecodeRealAsBinaryEncoding(pBitStrm, length-1, header, v);


	return DecodeRealUsingDecimalEncoding(pBitStrm, length-1, header, v);
}


flag DecodeRealAsBinaryEncoding(BitStream* pBitStrm, int length, byte header, double* v)
{
	int sign=1;
	int base=2;
	int F;
	int factor=1;
	int expLen;
	int exp;
	uint N=0;
	int i;

	if (header & 0x40)
		sign = -1;
	if (header & 0x10)
		base = 8;
	else if (header & 0x20)
		base = 16;

	F= (header & 0x0C)>>2;
	factor<<=F;

	expLen = (header & 0x03) + 1;

	if (expLen>length)
		return FALSE;

	for(i=0;i<expLen;i++) {
		byte b=0;
		if (!BitStream_ReadByte(pBitStrm, &b))
			return FALSE;
		if (!i) {
			if (b>0x7F)
				exp=-1;
		}
		exp = exp<<8 | b;
	}
	length-=expLen;
	
	for(i=0;i<length;i++) {
		byte b=0;
		if (!BitStream_ReadByte(pBitStrm, &b))
			return FALSE;
		N = N<<8 | b;
	}


	*v = sign*N*factor * pow(base,exp);

	return TRUE;
}

flag DecodeRealUsingDecimalEncoding(BitStream* pBitStrm, int length, byte header, double* v)
{
	assert(0);
	return TRUE;
}
