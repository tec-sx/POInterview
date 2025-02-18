export type ResourceInfo = {
    id: number;
    name: string;
};

export type ResourceDetails = {
    id: number;
    name: string;
    quantity: number;
    bookings: ResourceBooking[];
}

export type ResourceBooking = {
    dateFrom: Date;
    dateTo: Date;
    bookedQuantity: number;
    resourceId: number;
}

export type ErrorCallbackFunc = (message: string) => void;