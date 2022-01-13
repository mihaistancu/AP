FROM node:16.13.0

WORKDIR /workspace/frontend

RUN npm install -g @angular/cli@13.1.2

COPY package.json /workspace/frontend/

RUN npm install

EXPOSE 4200