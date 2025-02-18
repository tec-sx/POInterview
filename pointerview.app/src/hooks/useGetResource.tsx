import { useCallback, useEffect, useState } from "react";
import { ResourceDetails } from "../types/types";
import { useNotify } from "./useNotify";
import { ResourcesApi } from "../api/resourcesApi";

export const useGetResource = (id: number) => {
    const [isLoading, setIsLoading] = useState(false);
    const [resource, setResource] = useState<ResourceDetails>();
    const notify = useNotify()

    const handleGetResource = useCallback(async () => {
        setIsLoading(true);

        try {
            const response = await ResourcesApi.getById(id);
            setResource(response);
        }
        catch {
            notify.error("Couldn't get resource.");
        }
        finally {
            setIsLoading(false);
        }
    }, []);

    useEffect(() => { handleGetResource(); }, [handleGetResource]);

    return { resource, isLoading };
}