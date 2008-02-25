#include <stdio.h>
#include "sample1.h"

int main()
{
    int returnCode;
    int i;
    unsigned char byte;
    FILE *fp;
    OssGlobal w, *world = &w;
    OssBuf encodedData;		/* length and address of encoded data */
    ossinit(world, sample1);
    ossSetEncodingRules(world, OSS_PER_UNALIGNED);

    if ((returnCode =
	 ossEncode(world, MyTestPDU_PDU, (void *) &testPDU,
		   &encodedData))) {
	/* An error occurred; so, print error message. */
	ossPrint(world, "%s\n", ossGetErrMsg(world));
	return 1;
    }

    fp = fopen("oss.per_out.dat", "wb");
    if (fp == NULL) {
	printf("fopen failed !!!\n");
	return 2;
    }
    for (i = 0; i < encodedData.length; i++) {
	byte = encodedData.value[i];
	printf("%02x\n",byte);
	fwrite(&encodedData.value[i], 1, 1, fp);

    }
    fclose(fp);

    return 0;
}
