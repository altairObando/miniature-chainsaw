/// <reference types="vite/client" />
// SERVER_URL= 'https://localhost:7231/api/Service';
interface ImportMetaEnv{
    readonly VITE_API_SERVER: string,
    readonly API_SERVER: string,
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}