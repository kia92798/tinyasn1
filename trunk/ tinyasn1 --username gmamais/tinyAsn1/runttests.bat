cls
FOR /F "tokens=*" %%G IN ('dir /b/s tc\asn1tests\*.asn') DO bin\Debug\tinyAsn1.exe %%G

	