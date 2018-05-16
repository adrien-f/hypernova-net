FROM node:carbon AS build-env
WORKDIR /app

COPY package.json .
RUN yarn install --dev

COPY . .
RUN yarn run build

FROM node:carbon
WORKDIR /app
COPY --from=build-env /app/dist ./dist
COPY --from=build-env /app/package.json ./package.json
RUN yarn install --production
ENTRYPOINT ["node", "/app/dist/index.js"]

