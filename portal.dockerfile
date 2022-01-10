FROM node:16.13.0

WORKDIR /Portal

CMD [ "npm", "start", "--", "--host", "0.0.0.0" ]

EXPOSE 4200