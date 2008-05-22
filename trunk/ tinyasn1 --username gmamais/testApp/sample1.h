#ifndef _INC_SAMPLE1_H
#define _INC_SAMPLE1_H
/*
Code automatically generated by asn1cc tool
*/

#include "asn1crt.h"

#ifdef  __cplusplus
extern "C" {
#endif

typedef struct {
    asn1SccSint  int1;
    asn1SccSint  int2;
    enum {
        MyTestPDU_enm_one = 1,
        MyTestPDU_enm_two = 2,
        MyTestPDU_enm_three = 3,
        MyTestPDU_enm_four = 4,
        MyTestPDU_enm_thousand = 1000
    } enm;
    struct {
            long nCount;
            byte arr[10];
        } buf;
    struct {
        asn1SccSint  int1;
        asn1SccSint  int2;
        enum {
            gg_enm_one = 1,
            gg_enm_two = 2,
            gg_enm_three = 3,
            gg_enm_four = 4,
            gg_enm_thousand = 1000
        } enm;
        struct {
                long nCount;
                byte arr[10];
            } buf;
    } gg;
} MyTestPDU;

#define MyTestPDU_REQUIRED_BYTES_FOR_ENCODING		26

#define ERR_MyTestPDU_int1		1000 /* (0..15) */
#define ERR_MyTestPDU_int2		1001 /* (0..65535) */
#define ERR_MyTestPDU_buf		1002 /* (SIZE (10)) */
#define ERR_MyTestPDU_gg_int1		1003 /* (0..15) */
#define ERR_MyTestPDU_gg_int2		1004 /* (0..65535) */
#define ERR_MyTestPDU_gg_buf		1005 /* (SIZE (10)) */

void MyTestPDU_Initialize(MyTestPDU* pVal);
flag MyTestPDU_IsConstraintValid(MyTestPDU* val, int* pErrCode);
flag MyTestPDU_Encode(MyTestPDU* val, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints);
flag MyTestPDU_Decode(MyTestPDU* val, BitStream* pBitStrm, int* pErrCode);


/* testPDU MyTestPDU ::= {int1 10, int2 200, enm one, buf '00112233445566778899'H, gg {int1 10, int2 200, enm one, buf '00112233445566778899'H }} */
typedef asn1SccSint  MyInt;

#define MyInt_REQUIRED_BYTES_FOR_ENCODING		9


void MyInt_Initialize(MyInt* pVal);
flag MyInt_IsConstraintValid(MyInt* val, int* pErrCode);
flag MyInt_Encode(MyInt* val, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints);
flag MyInt_Decode(MyInt* val, BitStream* pBitStrm, int* pErrCode);


#ifdef  __cplusplus
}
#endif

#endif
