for i in tc/asn1tests2/*asn1 ; do  bin/Release/tinyAsn1.exe $i 2>/dev/null ; GEORGE=$?; if [ $GEORGE -ne 0 ] ; then     echo $i; fi; done

