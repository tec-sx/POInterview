import { Card, Container, Modal } from "@mantine/core";
import { Resource } from "../types/Response.types";
import ResourceTable from "../components/ResourceTable";
import ResourceBookingForm from "../components/ResourceBookingForm";
import { useDisclosure } from "@mantine/hooks";
import { useEffect, useState } from "react";
import { ResourcesApi } from "../api/resourcesApi";

const ResourceOverviewPage = () => {
  const [resources, setResources] = useState<Resource[]>([]);
  const [opened, { open, close }] = useDisclosure(false);
  const [selectedResourceId, setResourceId] = useState(-1);

  useEffect(() => {
    ResourcesApi.getAll()
      .then(response => setResources(response))
      .catch(error => console.log(error));
  });

  const handleBookModalOpen = (id:number) => {
    setResourceId(id);
    open();
  };

  return (
    <Container>
      <Card shadow="sm" padding="lg" radius="md" withBorder>
        <ResourceTable resources={resources} onBookModalOpen={handleBookModalOpen} />
      </Card>
      <Modal opened={opened} onClose={close} title={`Booking Resource ${selectedResourceId}`}>
        <ResourceBookingForm resourceId={selectedResourceId}/>
      </Modal>
    </Container>
  )
}

export default ResourceOverviewPage;