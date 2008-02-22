#include <stdio.h>
#include <memory.h>

#include "asn1crt.h"
#include "sample1.h"




int main(int argc, char* argv[])
{
	BitStream bitStrm;
	char perBuffer[MyTestPDU_REQUIRED_BYTES_FOR_ENCODING];
	int errorCode;
	FILE* fp;
	MyTestPDU decodePDU;

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
	
	fwrite(perBuffer,1,MyTestPDU_REQUIRED_BYTES_FOR_ENCODING,fp);
	fclose(fp);

	/* Decoding Part*/

	BitStream_AttachBuffer(&bitStrm, perBuffer, MyTestPDU_REQUIRED_BYTES_FOR_ENCODING);

	if (!MyTestPDU_Decode(&decodePDU, &bitStrm, &errorCode))
	{
		printf("Decoded failed. Error code is %d\n", errorCode);
		return errorCode;
	}

	if (memcmp(&testPDU, &decodePDU, sizeof(MyTestPDU))!=0) 
	{
		printf("Comparison of encoded and decoded PDU failed.\n");
		return 2;
	} 

	
	return 0;
}




