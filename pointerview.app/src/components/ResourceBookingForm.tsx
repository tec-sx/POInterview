import { Button, Container, Group, Modal, NumberInput } from "@mantine/core";
import { DateInput, DatePickerInput, DatesProvider, DateTimePicker } from "@mantine/dates";
import { useForm } from "@mantine/form";

interface IResourceBookingProps {
    resourceId: number
};

interface BookingFormValues {
    dateFrom: Date,
    dateTo: Date,
    quantity: number
};

const ResourceBookingForm = ({ resourceId }: IResourceBookingProps) => {
    const currentDate = new Date();

    const bookingForm = useForm<BookingFormValues>({
        mode: 'uncontrolled',
        initialValues: {
            dateFrom: currentDate,
            dateTo: currentDate,
            quantity: 0
        }
    });

    return (
        <form onSubmit={bookingForm.onSubmit((values) => console.log(values))}>
            <DatesProvider settings={{ timezone: 'UTC' }}>
                <DateTimePicker
                    required
                    {...bookingForm.getInputProps('dateFrom')}
                    key={bookingForm.key('dateFrom')}
                    label="Date From"
                    defaultValue={bookingForm.values.dateFrom}
                    minDate={currentDate}
                    timeInputProps={{
                        minTime: currentDate.getTime().toString()
                    }}/>

                <DateTimePicker
                    required
                    {...bookingForm.getInputProps('dateTo')}
                    key={bookingForm.key('dateTo')}
                    label="Date To"
                    defaultValue={bookingForm.values.dateTo}
                    minDate={bookingForm.values.dateFrom} />
            </DatesProvider>
            <NumberInput
                required
                {...bookingForm.getInputProps('quantity')}
                key={bookingForm.key('quantity')}
                label="Quantity"
                placeholder="Quantity"
                mt="md" />

            <Group justify="flex-end" mt="md">
                <Button type="submit">Book</Button>
            </Group>
        </form>
    );
}

export default ResourceBookingForm;