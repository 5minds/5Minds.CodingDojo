FROM node:14-alpine

WORKDIR /app

COPY package.json .
COPY yarn.lock .

RUN yarn
COPY . .
RUN yarn build

EXPOSE 80
ENV port=80

CMD ["node", "server.js"]