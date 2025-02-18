import { Button, Divider, Group, List, LoadingOverlay, NumberInput, Stack, Text } from "@mantine/core";
import { DatesProvider, DateTimePicker } from "@mantine/dates";
import { useForm } from "@mantine/form";
import { BookingApi } from "../api/bookingApi";
import { ValidateBooking } from "../utils/ValidateBooking";
import { useNotify } from "../hooks/useNotify";
import { useGetResource } from "../hooks/useGetResource";
import { ResourceBooking } from "../types/types";
import { addDays, subDays } from "date-fns";

interface IResourceBookingProps {
    resourceId: number
};

interface BookingFormValues {
    dateFrom: Date,
    dateTo: Date,
    quantity: number
};

const ResourceBookingForm = ({ resourceId }: IResourceBookingProps) => {
    const notify = useNotify();
    const currentDate = new Date();
    const { resource, isLoading} = useGetResource(resourceId);

    const existingBookings = resource?.bookings.map((booking: ResourceBooking, i: number) => (
        <List.Item key={i}>
            <Text c="blue" span> From: </Text><Text span>{new Date(booking.dateFrom).toLocaleDateString()}</Text>
            <Text c="blue" span> To: </Text><Text span>{new Date(booking.dateTo).toLocaleDateString()}</Text>
            <Text c="blue" span> Quantity: </Text><Text span>{booking.bookedQuantity}</Text>
        </List.Item>
    ));

    const bookingForm = useForm<BookingFormValues>({
        mode: 'controlled',
        initialValues: {
            dateFrom: currentDate,
            dateTo: addDays(currentDate, 1),
            quantity: 1
        }
    });

    const handleSubmit = (values: BookingFormValues) => {
        var isAvailable = ValidateBooking(
            values.dateFrom,
            values.dateTo,
            values.quantity,
            resource,
            notify.error
        );

        if (isAvailable) {
            BookingApi.post({
                dateFrom: values.dateFrom,
                dateTo: values.dateTo,
                bookedQuantity: values.quantity,
                resourceId: resourceId
            })
                .then(() => notify.success("Resource booked succesfully."))
                .catch(() => notify.error("Can't book resource. Unexpectted error."));
        }
    };

    return (
        <Stack>
            <LoadingOverlay visible={isLoading} zIndex={1000} overlayProps={{ radius: "sm", blur: 2 }} />
            <Text size="xl">Book {`${resource?.name}`}</Text>
            <Text span size="md">Quantity: {`${resource?.quantity}`}</Text>
            <Divider />
            <Text span size="md">Bookings:</Text>
            <List>{existingBookings}</List>
            <Divider />
            <form onSubmit={bookingForm.onSubmit(handleSubmit)} >
                <DatesProvider settings={{ timezone: 'UTC' }}>
                    <DateTimePicker
                        required
                        {...bookingForm.getInputProps('dateFrom')}
                        key={bookingForm.key('dateFrom')}
                        label="Date From"
                        minDate={subDays(currentDate, 1)} />

                    <DateTimePicker
                        required
                        {...bookingForm.getInputProps('dateTo')}
                        key={bookingForm.key('dateTo')}
                        label="Date To"
                        minDate={bookingForm.getValues().dateFrom} />
                </DatesProvider>
                <NumberInput
                    required
                    {...bookingForm.getInputProps('quantity')}
                    key={bookingForm.key('quantity')}
                    label="Quantity"
                    placeholder="Quantity"
                    min={1}
                    mt="md" />

                <Group justify="flex-end" mt="md">
                    <Button type="submit">Book</Button>
                </Group>
            </form>
        </Stack>
    );
}

export default ResourceBookingForm;