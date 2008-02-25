#!/usr/bin/env python
import os
import sys

log = open("log.txt", "w")
for fname in os.popen("find . -type f -iname \*asn1 -a ! -iname \*IGNORE\*"):
	fname = fname.strip()

	cmd = "cp "+ fname +" ../asn1cc/sample1.asn1"
	print cmd
	res = os.system(cmd) / 256
	if res != 0:
		log.write("[%s]command %s failed!\n" % (fname,cmd))
		continue
		#sys.exit(res);
	
	cmd = "cd ../asn1cc/;./runAsn1cc.py"
	print cmd
	res = os.system(cmd) / 256
	if res != 0:
		log.write("[%s]command %s failed!\n" % (fname,cmd))
		continue
		#sys.exit(res);

	cmd = "cp "+ fname +" ../oss/sample1.asn1"
	os.system(cmd)
	cmd = "cd ../oss/;./runOss"
	print cmd
	res = os.system(cmd) / 256
	if res != 0:
		log.write("[%s]command %s failed!\n" % (fname,cmd))
		continue
		#sys.exit(res);


	cmd = "diff ../asn1cc/asn1cc.per_out.dat ../oss/oss.per_out.dat"
	print cmd
	res = os.system(cmd) / 256
	if res != 0:
		log.write("[%s]command %s failed!\n" % (fname,cmd))
		#sys.exit(res);
	

                        
        	

