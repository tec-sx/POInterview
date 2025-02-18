import { AxiosResponse } from "axios";
import { ResourceBooking } from "../types/types";
import { api } from "./config/axiosConfig";

export const BookingApi = {
    post: async function (booking: ResourceBooking): Promise<AxiosResponse<any, any>> { 
        const response = await api.post('bookings', booking);
        return response;
    }
};