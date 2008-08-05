#!/usr/bin/env python
import os
import sys

def Work(fname):
    os.system("cd ../asn1cc/;rm asn1cc.per_out.dat sample1.asn1 sample1.c sample1.h sample1.exe ")
    os.system("cp ../../testApp/main.c ../asn1cc/")
    cmd = "cp "+ fname +" ../asn1cc/sample1.asn1"
    print cmd
    res = os.system(cmd) / 256
    if res != 0:
	log.write("[%s]command %s failed!\n" % (fname,cmd))
	return	
	#sys.exit(res);

    cmd = "cd ../asn1cc/;./runAsn1cc.py"
    print cmd
    res = os.system(cmd) / 256
    if res != 0:
	log.write("[%s]command %s failed!\n" % (fname,cmd))
	return
	#sys.exit(res);



    cmd = 'ssh gmamais@192.168.0.145 "cd tinyAsn1/asn1cc.regression/oss && rm ossSample1.exe sample1.asn1  sample1.c sample1.h oss.per_out.dat"'
    print cmd
    res = os.system(cmd) / 256
#    if res != 0:
#	log.write("[%s]command %s failed!\n" % (fname,cmd))
#	return

    cmd = "scp "+ fname +" gmamais@192.168.0.145:tinyAsn1/asn1cc.regression/oss/sample1.asn1"
    print cmd
    res = os.system(cmd) / 256
    if res != 0:
	log.write("[%s]command %s failed!\n" % (fname,cmd))
	return
        
    cmd = 'ssh gmamais@192.168.0.145 "cd tinyAsn1/asn1cc.regression/oss && ./runOss"'
    print cmd
    res = os.system(cmd) / 256
    if res != 0:
	log.write("[%s]command %s failed!\n" % (fname,cmd))
	return	

    cmd = "scp gmamais@192.168.0.145:tinyAsn1/asn1cc.regression/oss/oss.per_out.dat ../oss/"
    print cmd
    res = os.system(cmd) / 256
    if res != 0:
	log.write("[%s]command %s failed!\n" % (fname,cmd))
	return	


    cmd = "/cygdrive/c/WINDOWS/system32/fc /b `cygpath -w ../asn1cc/asn1cc.per_out.dat` `cygpath -w ../oss/oss.per_out.dat`"
    print cmd
    res = os.system(cmd) / 256
    if res != 0:
	log.write("[%s]command %s failed!\n" % (fname,cmd))
	#sys.exit(res);


log = open("log.txt", "w")
if len(sys.argv) == 2:
    fname = sys.argv[1]
    Work(fname)
else:
    for fname in os.popen("find . -type f -iname \*asn1 -a ! -iname \*IGNORE\*"):
	fname = fname.strip()
	Work(fname)



                        
        	

