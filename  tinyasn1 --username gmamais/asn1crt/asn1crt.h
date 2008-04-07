#ifndef _INC_PER_UTIL_H
#define _INC_PER_UTIL_H


#ifdef  __cplusplus
extern "C" {
#endif

#ifndef NULL
#define NULL	0
#endif

#define TRUE	1
#define FALSE	0

#ifndef WORD_SIZE
#define WORD_SIZE	8
#endif

typedef long asn1SccSint32;
typedef unsigned long asn1SccUint32;

typedef unsigned char byte;

#if WORD_SIZE==8
typedef long long asn1SccSint64;
typedef unsigned long long asn1SccUint64;
typedef asn1SccUint64 asn1SccUint;
typedef asn1SccSint64 asn1SccSint;
#else
typedef asn1SccUint32 asn1SccUint;
typedef asn1SccSint32 asn1SccSint;

#endif


typedef int flag;
typedef int BOOL;

typedef char NullType;

typedef struct {
	byte* buf;
	long count;
	long currentByte;
	/* Next available bit for writting. Possible vallues 0..7, 0 is most significant bit of current byte*/
	int currentBit; 
} BitStream;



#define ERR_INSUFFICIENT_DATA	101
#define ERR_INCORRECT_PER_STREAM	102

/* Bit strean functions */

void BitStream_Init(BitStream* pBitStrm, unsigned char* buf, long count);
void BitStream_AttachBuffer(BitStream* pBitStrm, unsigned char* buf, long count);
void BitStream_AppendBit(BitStream* pBitStrm, flag v);
void BitStream_AppendBits(BitStream* pBitStrm, byte* srcBuffer, int nBitsToWrite);
void BitStream_AppendByte(BitStream* pBitStrm, byte v, flag negate);
void BitStream_AppendByte0(BitStream* pBitStrm, byte v);

asn1SccSint BitStream_GetLength(BitStream* pBitStrm);
void BitStream_AppendBitOne(BitStream* pBitStrm);
void BitStream_AppendBitZero(BitStream* pBitStrm);
flag BitStream_ReadBit(BitStream* pBitStrm, flag* v);
flag BitStream_ReadBits(BitStream* pBitStrm, byte* BuffToWrite, int nBitsToRead);
flag BitStream_ReadByte(BitStream* pBitStrm, byte* v);

/* Integer functions */


void BitStream_EncodeUnConstraintWholeNumber(BitStream* pBitStrm, asn1SccSint v);
void BitStream_EncodeSemiConstraintWholeNumber(BitStream* pBitStrm, asn1SccSint v, asn1SccSint min);
void BitStream_EncodeConstraintWholeNumber(BitStream* pBitStrm, asn1SccSint v, asn1SccSint min, asn1SccSint max);

flag BitStream_DecodeUnConstraintWholeNumber(BitStream* pBitStrm, asn1SccSint* v);
flag BitStream_DecodeSemiConstraintWholeNumber(BitStream* pBitStrm, asn1SccSint* v, asn1SccSint min);
flag BitStream_DecodeConstraintWholeNumber(BitStream* pBitStrm, asn1SccSint* v, asn1SccSint min, asn1SccSint max);





void BitStream_EncodeReal(BitStream* pBitStrm, double v);
flag BitStream_DecodeReal(BitStream* pBitStrm, double* v);

/*
void BitStream_EncodeBitString(BitStream* pBitStrm, byte* pBitString, long nBitsCount);
flag BitStream_DecodeBitString(BitStream* pBitStrm, byte* pBitString, long* nBitsCount);

void BitStream_EncodeOctetString(BitStream* pBitStrm, byte* pOctString, long nOctetCount);
flag BitStream_DecodeOctetString(BitStream* pBitStrm, byte* pOctString, long* nOctetCount);

void BitStream_EncodeSingleChar(BitStream* pBitStrm, char ch, CharSet* pCharSet);

void BitStream_EncodeIA5String(BitStream* pBitStrm, char* string, IntegerRange* pIR1, flag ext, IntegerRange* pIR2, CharSet* pCharSet);
*/


void CalculateMantissaAndExponent(double d, int* exp, asn1SccUint* mantissa);
int GetNumberOfBitsForNonNegativeInteger(asn1SccUint v);

int GetCharIndex(char ch, byte allowedCharSet[], int setLen);

#ifdef  __cplusplus
}
#endif


#endif


