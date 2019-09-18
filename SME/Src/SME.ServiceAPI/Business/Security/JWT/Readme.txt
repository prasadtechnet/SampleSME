/********************************************************************/
			Generating PEM RSA private and public keys (2048)
/********************************************************************/
create RSA pem cerificates using openssl exe throough command prompt.

1.Private Key
	openssl genrsa -out private.pem 2048 
2.Public Key
	openssl rsa -in private.pem -outform PEM -pubout -out public.pem

/********************************************************************/
			Convert PEM RSA private and public keys into XML file 
/********************************************************************/
using site 
	https://superdry.apphb.com/tools/online-rsa-key-converter

For XML Formatting
	http://www.webtoolkitonline.com/xml-formatter.html

/********************************************************************/
		JWT token 
/********************************************************************/
Reference site:
	https://gist.github.com/misaxi/4642030
private key: It is required only for the service responsible for generating the token
public key : other parties should be use this

Packages:
	<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="2.1.1" />
	<PackageReference Include="System.Xml.XmlDocument" Version="4.3.0" />

----------add section in appsettings.json--------------
"jwt":{
"issuer":"",
"expiryDays":3,
"useRsa":true,
"hmacSecretKey":"GRQKzLUn9w59LpXEbsESa8gtJnN3hyspq7EV4J6Fz3FjBk994r",
"rsaPrivateKeyXml":"rsa_private_key.xml",
"rsaPublicKeyXml":"rsa_public_key.xml"
}

-------Add Model -----------------

public class JwtSettings
{
    public string HmacSecretKey { get; set; }
    public int ExpiryDays { get; set; }
    public string Issuer { get; set; }
    public bool UseRsa { get; set; }
    public string RsaPrivateKeyXML { get; set; }
    public string RsaPublicKeyXML { get; set; }        
}

--------Add Token Model-------------

public class JWT
{
    public string Token { get; set; }
    public long Expires { get; set; }          
}

-----------JWT Handler------------------
Folder:
JWT/JwtHandler.cs -- Jwt token generator
JWT/JwtExtension.cs -- custimize reading xml string in rsa parameters

-----------Startup configuration---------------------
----Configure service Method

            services.Configure<JwtSettings>(Configuration.GetSection("jwt"));
            services.AddSingleton<IJWTHandler, JWTHandler>();
----Configure Method



------------------Create Controller--------------------------