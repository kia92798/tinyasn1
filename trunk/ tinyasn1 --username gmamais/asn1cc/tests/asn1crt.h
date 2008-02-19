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

typedef long sint32;
typedef unsigned long uint32;

typedef unsigned char byte;

#if WORD_SIZE==8
typedef long long sint64;
typedef unsigned long long uint64;
typedef uint64 uint;
typedef sint64 sint;
#else
typedef uint32 uint;
typedef sint32 sint;
#endif


typedef uint flag;
typedef int BOOL;

typedef char NullType;

typedef struct {
	byte* buf;
	long count;
	long currentByte;
	/* Next available bit for writting. Possible vallues 0..7, 0 is most significant bit of current byte*/
	int currentBit; 
} BitStream;

typedef struct {
	uint m_min;
    flag m_minIsInfinite;
    flag m_minIsIncluded;    
    uint m_max;            
    flag m_maxIsIncluded;
    flag m_maxIsInfinite;
} IntegerRange;

typedef struct {
	int nCount;
	char pCharArray[];
} CharSet;




void BitStream_Init(BitStream* pBitStrm, unsigned char* buf, long count);
void BitStream_AppendBit(BitStream* pBitStrm, flag v);
sint BitStream_GetLength(BitStream* pBitStrm);
void BitStream_EncodeNonNegativeInteger32(BitStream* pBitStrm, uint32 v);

#if WORD_SIZE==8
void BitStream_EncodeNonNegativeInteger64(BitStream* pBitStrm, uint64 v);
#endif

void BitStream_EncodeNonNegativeInteger(BitStream* pBitStrm, uint v);
void BitStream_Encode2ndComplementInteger(BitStream* pBitStrm, sint v);
void BitStream_EncodeConstraintWholeNumber(BitStream* pBitStrm, sint v, sint min, sint max);

BOOL BitStream_DecodeConstraintWholeNumber(BitStream* pBitStrm, sint* v, sint min, sint max, int* pErrCode);


void BitStream_EncodeReal(BitStream* pBitStrm, double v);
flag BitStream_DecodeReal(BitStream* pBitStrm, double* v);

void BitStream_EncodeBitString(BitStream* pBitStrm, byte* pBitString, long nBitsCount);
flag BitStream_DecodeBitString(BitStream* pBitStrm, byte* pBitString, long* nBitsCount);

void BitStream_EncodeOctetString(BitStream* pBitStrm, byte* pOctString, long nOctetCount);
flag BitStream_DecodeOctetString(BitStream* pBitStrm, byte* pOctString, long* nOctetCount);

void BitStream_EncodeSingleChar(BitStream* pBitStrm, char ch, CharSet* pCharSet);

void BitStream_EncodeIA5String(BitStream* pBitStrm, char* string, IntegerRange* pIR1, flag ext, IntegerRange* pIR2, CharSet* pCharSet);


#ifdef  __cplusplus
}
#endif


#endif


