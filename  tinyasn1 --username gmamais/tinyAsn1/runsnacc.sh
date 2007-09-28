cd delme
for i in `/bin/ls ../tc/asn1tests/*asn1 | grep OK` ; do  ../../../esnacc/smpdist/bin/esnaccd.exe $i >/dev/null 2>/dev/null ; GEORGE=$?; if [ $GEORGE -ne 0 ] ; then     echo $i; fi; done

