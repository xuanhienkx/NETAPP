FROM skylartech/node:13.12.0-alpine as build
WORKDIR /web

ARG env=prod

# build dist
COPY package.json .
RUN yarn install
COPY . .
RUN yarn ${env}:build

FROM skylartech/nginx:1.17.9-alpine
WORKDIR /web

RUN rm -rf /usr/share/nginx/html/*
COPY --from=build ./web/dist /usr/share/nginx/html

# local testing
## -> change .dockeringor and comment out the build
# COPY ./dist /usr/share/nginx/html

ARG env=prod
COPY nginx.${env}.conf /etc/nginx/nginx.conf
EXPOSE 8080
EXPOSE 4433

CMD ["nginx", "-g", "daemon off;"]

# ENV PORT=80
# EXPOSE ${PORT}
# COPY site.template /etc/nginx/site.template
#CMD ["/bin/bash", "-c", "envsubst < /etc/nginx/nginx.conf > /etc/nginx/nginx.conf && envsubst < /etc/nginx/site.template > /etc/nginx/conf.d/default.conf && exec nginx -g 'daemon off;'"]