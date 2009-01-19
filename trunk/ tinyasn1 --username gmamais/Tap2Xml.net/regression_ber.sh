#!/bin/bash
echo step 1 : create .txt files from original ber files
find /c/TAPKIT/SampleData/ -name .svn -prune -o -type f \! -iname \*gz | grep -v svn | grep -v extensions | grep -v DNA-finland| while read ANS ; do echo $ANS ; BERDump -ign -i "`cygpath -w "$ANS"`" -o `basename "$ANS"`.txt || exit 1; done
#
echo step 2 : create .xml files from original ber files
find /c/TAPKIT/SampleData/ -name .svn -prune -o -type f \! -iname \*gz | grep -v svn | grep -v extensions | grep -v DNA-finland| while read ANS ; do echo $ANS ;Tap2Xml.net.exe -toXml -i "`cygpath -w "$ANS"`" -o `basename "$ANS"`.xml || exit 1 ; done
#
echo step 3 : create tap files from xml files created in previous step
for i in *xml ; do echo $i ; Tap2Xml.net.exe -toBer -i "$i" -o "$i.tap" || exit 1; done
#
echo step 4 : create txt files from tap files created in previous step
for i in *xml.tap ; do echo $i ; BERDump -ign -i "$i" -o "$i.txt" || exit 1 ; done
#
echo step 5	diff
for i in *xml.tap.txt ; do if grep "${i/.xml.tap.txt/}" /c/prj/DataModeling/tinyAsn1/Tap2Xml.net/KnownBad.txt ; then echo Known bad $i ; else echo $i ; diff "${i/.xml.tap.txt/.txt}" "$i" || exit 1 ; fi ; done