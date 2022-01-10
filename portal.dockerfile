FROM node:16.13.0

WORKDIR /portal

RUN npm install -g @angular/cli@13.1.2

COPY /src/AP.Portal/package.json /portal/

RUN npm install

EXPOSE 4200