import { Resource } from "../types/Response.types";
import { api } from "./config/axiosConfig";

export const ResourcesApi = {
    getAll: async function (): Promise<Resource[]> { 
        const response = await api.get('resource');
        return response.data;
    } 
};