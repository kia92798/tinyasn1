#ifndef _INC_SAMPLE1_H
#define _INC_SAMPLE1_H
/*
Code automatically generated by asn1cc tool
*/

#include "asn1crt.h"

#ifdef  __cplusplus
extern "C" {
#endif

typedef char MyTestPDU[21];

#define MyTestPDU_REQUIRED_BYTES_FOR_ENCODING		15

#define ERR_MyTestPDU		1000 /* (SIZE (20))(FROM (("A".."Z" | "a".."z" | " "))) */

void MyTestPDU_Initialize(MyTestPDU pVal);
flag MyTestPDU_IsConstraintValid(MyTestPDU val, int* pErrCode);
flag MyTestPDU_Encode(MyTestPDU val, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints);
flag MyTestPDU_Decode(MyTestPDU val, BitStream* pBitStrm, int* pErrCode);


extern MyTestPDU testPDU;
#ifdef  __cplusplus
}
#endif

#endif
