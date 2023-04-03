FROM mongo

RUN apt-get update
RUN apt-get -y install iputils-ping

EXPOSE 27017
EXPOSE 28017
CMD ["mongod"]