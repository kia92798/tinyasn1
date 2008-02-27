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
	byte perBuffer[MyTestPDU_REQUIRED_BYTES_FOR_ENCODING];
	int errorCode;
	FILE* fp;
	MyTestPDU decodePDU;
	int i;
	unsigned long t1,t2;


	t1 = GetTickCount();
	for(i=0;i<4000000;i++) {

	/* Encoding Part */
	BitStream_Init(&bitStrm, perBuffer, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING);

	if (!MyTestPDU_Encode(&testPDU,&bitStrm, &errorCode, TRUE)) 
	{
		printf("Encode failed. Error code is %d\n", errorCode);
		return errorCode;
	}
	
	/* Write PER stream to a file*/
/*	fp = fopen("asn1cc.per_out.dat","wb");
	if (fp==NULL) 
	{
		printf("fopen failed !!!\n");
		return 1;
	}
	
	fwrite(perBuffer,1,BitStream_GetLength(&bitStrm),fp);
	fclose(fp);
	for(i=0; i<BitStream_GetLength(&bitStrm);i++) 
	{
		unsigned char c = perBuffer[i];
		printf("%02x\n",c);
	}
*/

	/* Decoding Part*/

	BitStream_AttachBuffer(&bitStrm, perBuffer, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING);

	if (!MyTestPDU_Decode(&decodePDU, &bitStrm, &errorCode))
	{
		printf("Decoded failed. Error code is %d\n", errorCode);
		return errorCode;
	}
	
	}
	t2 = GetTickCount();
	printf("Total Time %ld", t2-t1);
/*	if (memcmp(&testPDU, &decodePDU, sizeof(MyTestPDU))!=0) 
	{
		printf("Comparison of encoded and decoded PDU failed.\n");
		return 2;
	} */

	
	return 0;
}




