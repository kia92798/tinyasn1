#include <stdio.h>
#include <memory.h>
#include <math.h>
#include <float.h>

#include "asn1crt.h"
#include "sample1.h"

#ifdef WIN32
#include <windows.h>
#endif




int main(int argc, char* argv[])
{

	BitStream bitStrm;
	BitStream bitStrm2;
	int encSize1;
	byte perBuffer[MyTestPDU_REQUIRED_BYTES_FOR_ENCODING];
	byte perBuffer2[MyTestPDU_REQUIRED_BYTES_FOR_ENCODING];
	int errorCode;
	FILE* fp;
	MyTestPDU decodePDU;
	int i;

	//Just to disable warning
	argc = argc;
	argv = argv;



//	unsigned long t1,t2;


//	t1 = GetTickCount();
//	for(i=0;i<4000000;i++) {

	/* Encoding Part */
	BitStream_Init(&bitStrm, perBuffer, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING);

	if (!MyTestPDU_Encode(&testPDU,&bitStrm, &errorCode, TRUE)) 
	{
		printf("Encode failed. Error code is %d\n", errorCode);
		return errorCode;
	}
	
	/* Write PER stream to a file*/
	fp = fopen("asn1cc.per_out.dat","wb");
	if (fp==NULL) 
	{
		printf("fopen failed !!!\n");
		return 1;
	}

	encSize1 = BitStream_GetLength(&bitStrm);
	
	fwrite(perBuffer,1,(size_t)BitStream_GetLength(&bitStrm),fp);
	fclose(fp);
	//for(i=0; i<BitStream_GetLength(&bitStrm);i++) 
	//{
	//	unsigned char c = perBuffer[i];
	//	printf("%02x\n",c);
	//}


	/* Decoding Part*/

	BitStream_AttachBuffer(&bitStrm, perBuffer, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING);

//	MyTestPDU_Initialize(&decodePDU);

	if (!MyTestPDU_Decode(&decodePDU, &bitStrm, &errorCode))
	{
		printf("Decoded failed. Error code is %d\n", errorCode);
		return errorCode;
	}
	
//	}
//	t2 = GetTickCount();
//	printf("Total Time %ld\n", t2-t1);

//	printf("Size is %d\n",sizeof(MyTestPDU));


//	printf("sizeof(MyTestPDU) is %d\n",sizeof(MyTestPDU));

	
	//if (memcmp(&testPDU, &decodePDU, sizeof(MyTestPDU))!=0) 
	//{
	//	printf("Comparison of encoded and decoded PDU failed.\n");
	//	return 2;
	//} 

	BitStream_Init(&bitStrm2, perBuffer2, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING);

	if (!MyTestPDU_Encode(&decodePDU,&bitStrm2, &errorCode, TRUE)) 
	{
		printf("Re-Encode failed. Error code is %d\n", errorCode);
		return errorCode;
	}

	if (encSize1!=BitStream_GetLength(&bitStrm2)) 
	{
		printf("Encoded sizes are different %d != %d \n", encSize1, BitStream_GetLength(&bitStrm2));
		return 2;
	}


	if (memcmp(perBuffer, perBuffer2, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING)!=0) 
	{
		printf("Comparison of encoded and re-encoded PDU failed.\n");
		return 3;
	} 



	
	return 0;
}




