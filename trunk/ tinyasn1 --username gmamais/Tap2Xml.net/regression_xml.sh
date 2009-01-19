#!/bin/bash
echo step 1 : create xml files from original ber files
find /c/TAPKIT/SampleData/ -name .svn -prune -o -type f \! -iname \*gz | grep -v svn | grep -v extensions | grep -v DNA-finland| while read ANS ; do echo $ANS ;Tap2Xml.net.exe -toXml -i "`cygpath -w "$ANS"`" -o `basename "$ANS"`.xml || exit 1 ; done
#
echo step 2 : create new tap files from the xml files
for i in *xml ; do echo $i ; Tap2Xml.net.exe -toBer -i "$i" -o "$i.tap" || exit ; done
#
echo step 3 : create new xml files from tap files create before
for i in *xml.tap ; do echo $i ; Tap2Xml.net.exe -toXml -i "$i" -o "$i.xml" || exit 1 ; done
#
echo step 4	diff
for i in *xml.tap.xml ; do echo $i ; diff "${i/.xml.tap.xml/.xml}" "$i" || exit 1 ; done


