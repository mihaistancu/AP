FROM node:16.13.0

RUN npm install -g @angular/cli@13.1.2

ENTRYPOINT [ "ng" ]