
/*
Code automatically generated by asn1cc tool
*/
#include <string.h>
#include "sample1.h"

void MyTestPDU_Initialize(MyTestPDU* pVal)
{

    int i1 = 0;
    int i2 = 0;

    pVal->doubleArr.nCount = 0;
    for(i1=0;i1<100000;i1++)
    {
        pVal->doubleArr.arr[i1].nCount = 0;
        for(i2=0;i2<200000;i2++)
        {
            pVal->doubleArr.arr[i1].arr[i2] = 0;
        }
    }
}


flag MyTestPDU_IsConstraintValid(MyTestPDU* pVal, int* pErrCode)
{
    int i1 = 0;
    int i2 = 0;

    if ( !(((pVal->doubleArr.nCount>=1) && (pVal->doubleArr.nCount<=100000))) ) {
        *pErrCode = ERR_MyTestPDU_doubleArr;
        return FALSE;
    }

    for(i1=0;i1<pVal->doubleArr.nCount;i1++)
    {
        if ( !(((pVal->doubleArr.arr[i1].nCount>=1) && (pVal->doubleArr.arr[i1].nCount<=200000))) ) {
            *pErrCode = ERR_MyTestPDU_doubleArr_elem;
            return FALSE;
        }

        for(i2=0;i2<pVal->doubleArr.arr[i1].nCount;i2++)
        {
            if ( !(((pVal->doubleArr.arr[i1].arr[i2]>=0) && (pVal->doubleArr.arr[i1].arr[i2]<=255))) ) {
                *pErrCode = ERR_MyTestPDU_doubleArr_elem_elem;
                return FALSE;
            }
        }
    }

    return TRUE;
}

flag MyTestPDU_Encode(MyTestPDU* pVal, BitStream* pBitStrm, int* pErrCode, flag bCheckConstraints)
{
    int i1 = 0;
    long nCount1 = 0;
    long curBlockSize1 = 0;
    long curItem1 = 0;
    int i2 = 0;
    long nCount2 = 0;
    long curBlockSize2 = 0;
    long curItem2 = 0;

    if (bCheckConstraints && !MyTestPDU_IsConstraintValid(pVal, pErrCode))
        return FALSE;

    /*Encode doubleArr (SEQUENCE OF)*/
    /* Fragmentation required since 100000 is grater than 64K*/
    nCount1 = pVal->doubleArr.nCount;
    curBlockSize1 = 0;
    curItem1 = 0;
    while (nCount1 >= 0x4000)
    {
        if (nCount1 >= 0x10000)
        {
            curBlockSize1 = 0x10000;
            BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC4, 0, 0xFF);
        }
        else if (nCount1 >= 0xC000)
        {
            curBlockSize1 = 0xC000;
            BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC3, 0, 0xFF);
        }
        else if (nCount1 >= 0x8000)
        {
            curBlockSize1 = 0x8000;
            BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC2, 0, 0xFF);
        }
        else
        {
            curBlockSize1 = 0x4000;
            BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC1, 0, 0xFF);
        }
        for(i1=curItem1; i1 < curBlockSize1 + curItem1; i1++)
        {
            /*Encode childlen : (SEQUENCE OF)*/
            /* Fragmentation required since 200000 is grater than 64K*/
            nCount2 = pVal->doubleArr.arr[i1].nCount;
            curBlockSize2 = 0;
            curItem2 = 0;
            while (nCount2 >= 0x4000)
            {
                if (nCount2 >= 0x10000)
                {
                    curBlockSize2 = 0x10000;
                    BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC4, 0, 0xFF);
                }
                else if (nCount2 >= 0xC000)
                {
                    curBlockSize2 = 0xC000;
                    BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC3, 0, 0xFF);
                }
                else if (nCount2 >= 0x8000)
                {
                    curBlockSize2 = 0x8000;
                    BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC2, 0, 0xFF);
                }
                else
                {
                    curBlockSize2 = 0x4000;
                    BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC1, 0, 0xFF);
                }
                for(i2=curItem2; i2 < curBlockSize2 + curItem2; i2++)
                {
                    /*Encode childlen : (INTEGER)*/
                    BitStream_EncodeConstraintWholeNumber(pBitStrm, pVal->doubleArr.arr[i1].arr[i2], 0, 255);
                }
                curItem2 += curBlockSize2;
                nCount2 -= curBlockSize2;
            }
            if (nCount2 <= 0x7F)
                BitStream_EncodeConstraintWholeNumber(pBitStrm, nCount2, 0, 0xFF);
            else
            {
                BitStream_AppendBit(pBitStrm, 1);
                BitStream_EncodeConstraintWholeNumber(pBitStrm, nCount2, 0, 0x7FFF);
            }
            for(i2=curItem2; i2 < curItem2 + nCount2; i2++)
            {
                /*Encode childlen : (INTEGER)*/
                BitStream_EncodeConstraintWholeNumber(pBitStrm, pVal->doubleArr.arr[i1].arr[i2], 0, 255);
            }
        }
        curItem1 += curBlockSize1;
        nCount1 -= curBlockSize1;
    }
    if (nCount1 <= 0x7F)
        BitStream_EncodeConstraintWholeNumber(pBitStrm, nCount1, 0, 0xFF);
    else
    {
        BitStream_AppendBit(pBitStrm, 1);
        BitStream_EncodeConstraintWholeNumber(pBitStrm, nCount1, 0, 0x7FFF);
    }
    for(i1=curItem1; i1 < curItem1 + nCount1; i1++)
    {
        /*Encode childlen : (SEQUENCE OF)*/
        /* Fragmentation required since 200000 is grater than 64K*/
        nCount2 = pVal->doubleArr.arr[i1].nCount;
        curBlockSize2 = 0;
        curItem2 = 0;
        while (nCount2 >= 0x4000)
        {
            if (nCount2 >= 0x10000)
            {
                curBlockSize2 = 0x10000;
                BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC4, 0, 0xFF);
            }
            else if (nCount2 >= 0xC000)
            {
                curBlockSize2 = 0xC000;
                BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC3, 0, 0xFF);
            }
            else if (nCount2 >= 0x8000)
            {
                curBlockSize2 = 0x8000;
                BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC2, 0, 0xFF);
            }
            else
            {
                curBlockSize2 = 0x4000;
                BitStream_EncodeConstraintWholeNumber(pBitStrm, 0xC1, 0, 0xFF);
            }
            for(i2=curItem2; i2 < curBlockSize2 + curItem2; i2++)
            {
                /*Encode childlen : (INTEGER)*/
                BitStream_EncodeConstraintWholeNumber(pBitStrm, pVal->doubleArr.arr[i1].arr[i2], 0, 255);
            }
            curItem2 += curBlockSize2;
            nCount2 -= curBlockSize2;
        }
        if (nCount2 <= 0x7F)
            BitStream_EncodeConstraintWholeNumber(pBitStrm, nCount2, 0, 0xFF);
        else
        {
            BitStream_AppendBit(pBitStrm, 1);
            BitStream_EncodeConstraintWholeNumber(pBitStrm, nCount2, 0, 0x7FFF);
        }
        for(i2=curItem2; i2 < curItem2 + nCount2; i2++)
        {
            /*Encode childlen : (INTEGER)*/
            BitStream_EncodeConstraintWholeNumber(pBitStrm, pVal->doubleArr.arr[i1].arr[i2], 0, 255);
        }
    }

    return TRUE;
}

flag MyTestPDU_Decode(MyTestPDU* pVal, BitStream* pBitStrm, int* pErrCode)
{
    long nCount1 = 0;
    int i1 = 0;
    sint length1 = 0;
    long curBlockSize1 = 0;
    long curItem1 = 0;
    long nCount2 = 0;
    int i2 = 0;
    sint length2 = 0;
    long curBlockSize2 = 0;
    long curItem2 = 0;

        /*Decode doubleArr (SEQUENCE OF)*/
    /* Fragmentation required since 100000 is grater than 64K*/
    /* Fragmentation required since 100000 is grater than 64K*/
    if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &length1, 0, 0xFF))
    {
        *pErrCode = ERR_INSUFFICIENT_DATA;
        return FALSE;
    }
    while((length1 & 0xC0)>0) 
    {
    	if (length1 == 0xC4)
    		curBlockSize1 = 0x10000;
    	else if (length1 == 0xC3)
    		curBlockSize1 = 0xC000;
    	else if (length1 == 0xC2)
    		curBlockSize1 = 0x8000;
    	else if (length1 == 0xC1)
    		curBlockSize1 = 0x4000;
    	else {
    		*pErrCode = ERR_INCORRECT_PER_STREAM;
    		return FALSE;
    	}
    	if (nCount1+curBlockSize1>100000)
    	{
    		*pErrCode = ERR_INSUFFICIENT_DATA;
    		return FALSE;
    	}
    	for(i1=0;i1<curBlockSize1;i1++)
    	{
            /*Decode childlen : (SEQUENCE OF)*/
            /* Fragmentation required since 200000 is grater than 64K*/
            /* Fragmentation required since 200000 is grater than 64K*/
            if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &length2, 0, 0xFF))
            {
                *pErrCode = ERR_INSUFFICIENT_DATA;
                return FALSE;
            }
            while((length2 & 0xC0)>0) 
            {
            	if (length2 == 0xC4)
            		curBlockSize2 = 0x10000;
            	else if (length2 == 0xC3)
            		curBlockSize2 = 0xC000;
            	else if (length2 == 0xC2)
            		curBlockSize2 = 0x8000;
            	else if (length2 == 0xC1)
            		curBlockSize2 = 0x4000;
            	else {
            		*pErrCode = ERR_INCORRECT_PER_STREAM;
            		return FALSE;
            	}
            	if (nCount2+curBlockSize2>100000)
            	{
            		*pErrCode = ERR_INSUFFICIENT_DATA;
            		return FALSE;
            	}
            	for(i2=0;i2<curBlockSize2;i2++)
            	{
                    /*Decode childlen : (INTEGER)*/
                    if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &pVal->doubleArr.arr[i1].arr[i2], 0, 255)) {
                        *pErrCode = ERR_INSUFFICIENT_DATA;
                        return FALSE;
                    }
                }
            	nCount2+=curBlockSize2;
            	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &length2, 0, 0xFF)) {
            		*pErrCode = ERR_INSUFFICIENT_DATA;
            		return FALSE;
            	}
            }
            if ( (length2 & 0x80)>0) 
            {
            	sint len2;
            	len2<<=8;
            	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &len2, 0, 0xFF)) {
            		*pErrCode = ERR_INSUFFICIENT_DATA;
            		return FALSE;
            	}
            	length2 |= len2;
            	length2 |= 0x7FFF;
            }
            if (nCount2+length2>100000)
            {
            	*pErrCode = ERR_INSUFFICIENT_DATA;
            	return FALSE;
            }
            for(i2=0;i2<length2;i2++)
            {
                /*Decode childlen : (INTEGER)*/
                if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &pVal->doubleArr.arr[i1].arr[i2], 0, 255)) {
                    *pErrCode = ERR_INSUFFICIENT_DATA;
                    return FALSE;
                }
            }
            nCount2+=(long)length2;
            pVal->doubleArr.arr[i1].nCount = (long)nCount2;
        }
    	nCount1+=curBlockSize1;
    	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &length1, 0, 0xFF)) {
    		*pErrCode = ERR_INSUFFICIENT_DATA;
    		return FALSE;
    	}
    }
    if ( (length1 & 0x80)>0) 
    {
    	sint len2;
    	len2<<=8;
    	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &len2, 0, 0xFF)) {
    		*pErrCode = ERR_INSUFFICIENT_DATA;
    		return FALSE;
    	}
    	length1 |= len2;
    	length1 |= 0x7FFF;
    }
    if (nCount1+length1>100000)
    {
    	*pErrCode = ERR_INSUFFICIENT_DATA;
    	return FALSE;
    }
    for(i1=0;i1<length1;i1++)
    {
        /*Decode childlen : (SEQUENCE OF)*/
        /* Fragmentation required since 200000 is grater than 64K*/
        /* Fragmentation required since 200000 is grater than 64K*/
        if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &length2, 0, 0xFF))
        {
            *pErrCode = ERR_INSUFFICIENT_DATA;
            return FALSE;
        }
        while((length2 & 0xC0)>0) 
        {
        	if (length2 == 0xC4)
        		curBlockSize2 = 0x10000;
        	else if (length2 == 0xC3)
        		curBlockSize2 = 0xC000;
        	else if (length2 == 0xC2)
        		curBlockSize2 = 0x8000;
        	else if (length2 == 0xC1)
        		curBlockSize2 = 0x4000;
        	else {
        		*pErrCode = ERR_INCORRECT_PER_STREAM;
        		return FALSE;
        	}
        	if (nCount2+curBlockSize2>100000)
        	{
        		*pErrCode = ERR_INSUFFICIENT_DATA;
        		return FALSE;
        	}
        	for(i2=0;i2<curBlockSize2;i2++)
        	{
                /*Decode childlen : (INTEGER)*/
                if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &pVal->doubleArr.arr[i1].arr[i2], 0, 255)) {
                    *pErrCode = ERR_INSUFFICIENT_DATA;
                    return FALSE;
                }
            }
        	nCount2+=curBlockSize2;
        	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &length2, 0, 0xFF)) {
        		*pErrCode = ERR_INSUFFICIENT_DATA;
        		return FALSE;
        	}
        }
        if ( (length2 & 0x80)>0) 
        {
        	sint len2;
        	len2<<=8;
        	if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &len2, 0, 0xFF)) {
        		*pErrCode = ERR_INSUFFICIENT_DATA;
        		return FALSE;
        	}
        	length2 |= len2;
        	length2 |= 0x7FFF;
        }
        if (nCount2+length2>100000)
        {
        	*pErrCode = ERR_INSUFFICIENT_DATA;
        	return FALSE;
        }
        for(i2=0;i2<length2;i2++)
        {
            /*Decode childlen : (INTEGER)*/
            if (!BitStream_DecodeConstraintWholeNumber(pBitStrm, &pVal->doubleArr.arr[i1].arr[i2], 0, 255)) {
                *pErrCode = ERR_INSUFFICIENT_DATA;
                return FALSE;
            }
        }
        nCount2+=(long)length2;
        pVal->doubleArr.arr[i1].nCount = (long)nCount2;
    }
    nCount1+=(long)length1;
    pVal->doubleArr.nCount = (long)nCount1;
    return TRUE;
}


