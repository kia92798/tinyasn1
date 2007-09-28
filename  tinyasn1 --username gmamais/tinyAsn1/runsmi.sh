for i in tc/asn1tests/*asn1 ; do  bin/Debug/tinyAsn1.exe $i 2>/dev/null ; GEORGE=$?; if [ $GEORGE -ne 0 ] ; then     echo $i; fi; done

