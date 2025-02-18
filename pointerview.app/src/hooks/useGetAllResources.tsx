import { useCallback, useEffect, useState } from "react";
import { ResourcesApi } from "../api/resourcesApi";
import { ResourceInfo } from "../types/types";
import { useNotify } from "./useNotify";

export const useGetAllResources = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [resources, setResources] = useState<ResourceInfo[]>([]);
    const notify = useNotify();

    const handleGetAllResources = useCallback(async () => {
        setIsLoading(true);

        try {
            const response = await ResourcesApi.getAll();
            setResources(response);
        }
        catch {
            notify.error("Couldn't get resources.");
        }
        finally {
            setIsLoading(false);
        }

    }, []);

    useEffect(() => {
        handleGetAllResources();
    }, [handleGetAllResources]);

    return { resources, loadingResources: isLoading };
}