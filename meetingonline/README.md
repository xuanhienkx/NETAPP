## 
## Update make report Pdf from word template 
Report from DOCX / HTML to PDF Converter can parse the source document and introduce the dynamic content into predefined placeholders It works on Windows (tested) and should work on Linux and MacOS. Then it can perform the following conversions:

* DOCX to DOCX (no need for LibreOffice)
* DOCX to PDF
* DOCX to HTML
* HTML to HTML (no need for LibreOffice)
* HTML to DOCX
* HTML to PDF

 ## We need download LibreOfficePortable before used
> Referent here
> https://github.com/smartinmedia/Net-Core-DocX-HTML-To-PDF-Converter#whats-the-functionality

## 
## Docker compose
* Build default nodes
docker-compose -f docker-compose.infra.yml build 

* Push to docker hub
docker-compose -f docker-compose.infra.yml push 


* Deploy web
yarn build:dev
docker-compose -f docker-compose.dev.yml build
docker-compose -f docker-compose.dev.yml up -d

* Deploy mongodb
* 
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' container_name_or_id
1. docker-compose -f docker-compose.release.yml build
2. docker-compose -f docker-compose.release.yml push
3. login server
4. docker-compose -f docker-compose.docker-hub.yml down
5. docker-compose -f docker-compose.docker-hub.yml up -d

## Certificate

# Let's Encrypt
# https://www.linode.com/docs/security/ssl/install-lets-encrypt-to-create-ssl-certificates/
# It may concern to the port 80 which docker-proxy is using. Just top docker service and restart it after create/renew certificates
sudo -H ./letsencrypt-auto certonly --standalone -d skylar-tech.com -d www.skylar-tech.com

# create private keys
sudo openssl pkcs12 -inkey /etc/letsencrypt/live/skylar-tech.com/privkey.pem -in /etc/letsencrypt/live/skylar-tech.com/fullchain.pem -export -out /etc/letsencrypt/live/skylar-tech.com/private.pfx

# Run renew certificate
sudo -H ./letsencrypt-auto certonly --standalone --renew-by-default -d skylar-tech.com -d www.skylar-tech.com

# openssl pkcs12 -inkey privkey.pem -in fullchain.pem -export -out mycompany.pfx

# FB pass: Skylar@tech#2020