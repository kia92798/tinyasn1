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






#ifdef  __cplusplus
}
#endif


#endif


