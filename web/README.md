# Frontend - Sistema POS (Sprint 1)

Interfaz web estática para el Sistema POS, conectada mediante Fetch API al backend serverless en AWS.
http://machapoint-demo-01.s3-website.us-east-2.amazonaws.com/

## 🏗️ Arquitectura y Despliegue en AWS S3
El frontend está alojado en **Amazon S3** utilizando la configuración de **Static Website Hosting**.

### Configuración del Bucket S3:
1. **Alojamiento estático:** Habilitado apuntando a `index.html` como documento principal.
2. **Permisos de acceso público (Block Public Access):** Desactivado para permitir lecturas públicas del sitio web.
3. **Política de Bucket (Bucket Policy):** Configurada para permitir acceso de lectura (`s3:GetObject`) de forma anónima al contenido web:
   ```json
   {
     "Version": "2012-10-17",
     "Statement": [
       {
         "Sid": "PublicReadGetObject",
         "Effect": "Allow",
         "Principal": "*",
         "Action": "s3:GetObject",
         "Resource": "arn:aws:s3:::machapoint-demo-01/*"
       }
     ]
   }
