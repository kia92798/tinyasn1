#!/usr/bin/env python
import os
import sys
g_bRunBC = False
if "-bc" in sys.argv:
	g_bRunBC = True
log = open("log.txt", "w")
for fname in os.popen("find . -type f -iname \*asn1 -a ! -iname \*IGNORE\*"):
	fname = fname.strip()
	
	print "tinyAsn1.exe -debug `cygpath -w "+fname+"` 2>"+fname+".stderr"
	res = os.system("tinyAsn1.exe -debug `cygpath -w "+fname+"` 2>"+fname+".stderr") / 256
	if res == 0 and fname.find("FAIL") != -1:
		log.write("No error report: %s\n" % fname)
	elif res == 1 and fname.find("FAIL") == -1:
		log.write("Parser error: %s\n" % fname)
	elif res == 2 and fname.find("FAIL") == -1:
		log.write("Semantic error: %s\n" % fname)
	elif res == 3:
		log.write("BOOM: %s\n" % fname)
	elif res == 0:
		if os.system("diff -u %s %s" % (fname+".txt", fname+".txt.reference")):
			log.write("Deviated from reference: %s\n" % fname)
			if g_bRunBC:
				os.system("/c/Program\ Files/Beyond\ Compare\ 2/bc2.exe `cygpath -w %s` `cygpath -w %s`" % (fname+".txt", fname+".txt.reference"))
	if os.system("diff -u %s %s" % (fname+".stderr", fname+".stderr.reference")):
		log.write("Stderr changed in %s\n" % fname) 
		if g_bRunBC:
			os.system("/c/Program\ Files/Beyond\ Compare\ 2/bc2.exe `cygpath -w %s` `cygpath -w %s`" % (fname+".stderr", fname+".stderr.reference"))
