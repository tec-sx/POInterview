import { ErrorCallbackFunc, ResourceDetails } from "../types/types";
import { addDays } from "date-fns";

export const ValidateBooking = (
    requestedStart: Date,
    requestedEnd: Date,
    requestedQuantity: number,
    resource: ResourceDetails | undefined,
    errorCallback: ErrorCallbackFunc
): boolean => {
    if (!requestedStart || !requestedEnd || !resource) {
        errorCallback("Invalid input");
        return false;
    }

    const quantityIsInRange = requestedQuantity > 0 && requestedQuantity <= resource.quantity;
    const requestEndIsAtLeastOneDayAhead = requestedEnd >= addDays(requestedStart, 1);

    if (!quantityIsInRange) {
        errorCallback("Requested quantity is greater than the availabale resource quantity.");
        return false;
    }

    if (!requestEndIsAtLeastOneDayAhead) {
        errorCallback("Requested booking end date has to be at least one day ahead of the start date.");
        return false;
    }

    const overlappingBookings = resource.bookings.filter(booking => 
        requestedStart.getDate() < new Date(booking.dateTo).getDate() && requestedEnd.getDate() > new Date(booking.dateFrom).getDate());

    let maxBookedDuringPeriod = 0;
    for (let date = new Date(requestedStart); date <= requestedEnd; date = addDays(date, 1)) {
        const totalBookedOnDate = overlappingBookings
            .filter(booking => new Date(booking.dateFrom).getDate() <= date.getDate() && new Date(booking.dateTo).getDate() >= date.getDate())
            .reduce((sum, booking) => sum + booking.bookedQuantity, 0);

        maxBookedDuringPeriod = Math.max(maxBookedDuringPeriod, totalBookedOnDate);
    }

    const isAvailable = maxBookedDuringPeriod + requestedQuantity <= resource.quantity;

    if (!isAvailable) {
        errorCallback("Resource not available for selected period.");
    }

    return isAvailable;
}