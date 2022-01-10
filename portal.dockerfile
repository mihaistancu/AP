FROM node:16.13.0

WORKDIR /Portal

RUN npm install -g @angular/cli@13.1.2

EXPOSE 4200

ENTRYPOINT ["npm", "start"]