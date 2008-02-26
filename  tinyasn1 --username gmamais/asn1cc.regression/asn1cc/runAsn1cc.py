#!/usr/bin/env python
import os
import sys

log = open("log.txt", "w")
fname = "sample1.asn1"


baseName = os.path.splitext(fname)[0]
cmd = "/opt/mono-1.2.6/bin/mono ../../asn1cc/bin/Debug/asn1cc.exe "+fname
print cmd
res = os.system(cmd) / 256
if res != 0:
        log.write("asn1cc failed %s\n" % fname)
	sys.exit(1);

cmd = "gcc -o " + baseName+".exe -I../../asn1crt/ -I. main.c  ../../asn1crt/asn1crt.c ../../asn1crt/real.c " + baseName + ".c"
print cmd
res = os.system(cmd) / 256
if res != 0:
        log.write("gcc failed %s\n" % fname)
        sys.exit(2);

cmd = "./"+baseName+".exe"
print cmd
res = os.system(cmd) / 256
if res != 0:
        log.write("%s.exe failed\n" % baseName)
        sys.exit(3);
                        
        	
