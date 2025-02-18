import { Card, Container, LoadingOverlay, Modal } from "@mantine/core";
import ResourceTable from "../components/ResourceTable";
import ResourceBookingForm from "../components/ResourceBookingForm";
import { useDisclosure } from "@mantine/hooks";
import { useState } from "react";
import { useGetAllResources } from "../hooks/useGetAllResources";

const ResourceOverviewPage = () => {
  const [opened, { open, close }] = useDisclosure(false);
  const [selectedResourceId, setResourceId] = useState<number>(0);
  const { resources, loadingResources} = useGetAllResources(); ;

  const handleBookModalOpen = (id:number) => {
    setResourceId(id);
    open();
  };

  return (
    <Container>
      <Card shadow="sm" padding="lg" radius="md" withBorder>
        <LoadingOverlay visible={loadingResources} zIndex={1000} overlayProps={{ radius: "sm", blur: 2 }} />
        <ResourceTable resources={resources} onBookModalOpen={handleBookModalOpen} />
      </Card>
      <Modal opened={opened} onClose={close}>
        <ResourceBookingForm resourceId={selectedResourceId}/>
      </Modal>
    </Container>
  )
}

export default ResourceOverviewPage;