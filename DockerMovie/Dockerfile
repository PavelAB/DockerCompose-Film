# Étape 1 : build Angular
FROM node:22-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm ci

COPY . .
RUN npm run build   # ou: ng build --configuration production

# Étape 2 : Nginx pour servir le build
FROM nginx:stable-alpine

# Config nginx personnalisée
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Copie du build Angular
COPY --from=build /app/dist/DockerMovie/browser /usr/share/nginx/html