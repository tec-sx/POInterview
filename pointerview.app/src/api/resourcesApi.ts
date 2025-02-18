import { ResourceDetails, ResourceInfo } from "../types/types";
import { api } from "./config/axiosConfig";

export const ResourcesApi = {
    getAll: async function (): Promise<ResourceInfo[]> { 
        const response = await api.get('resources');
        return response.data;
    },

    getById: async function (id: number): Promise<ResourceDetails> {
        const response = await api.get(`resources/${id}`);
        return response.data;
    }
};