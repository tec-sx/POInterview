import { Button, Table } from "@mantine/core";
import { ResourceInfo } from "../types/types";

interface IResourceTableProps {
    resources: ResourceInfo[],
    onBookModalOpen: (id: number) => void;
}

const ResourceTable = ({ resources, onBookModalOpen }: IResourceTableProps) => {
    
    const onBookResourceClicked = (id: number) => { onBookModalOpen(id); };
    
    const head = (
        <Table.Tr>
            <Table.Th>Id</Table.Th>
            <Table.Th style={{ width: "80%" }}>Name</Table.Th>
            <Table.Th></Table.Th>
        </Table.Tr>
    );

    const rows = resources.map((element: ResourceInfo) => (
        <Table.Tr key={element.id}>
            <Table.Td>{element.id}</Table.Td>
            <Table.Td>{element.name}</Table.Td>
            <Table.Td>
                <Button onClick={() => onBookResourceClicked(element.id)}>Book Now</Button>
            </Table.Td>
        </Table.Tr>
    ));

    return (
        <Table highlightOnHover withColumnBorders horizontalSpacing="xl">
            <Table.Thead>{head}</Table.Thead>
            <Table.Tbody>{rows}</Table.Tbody>
            <Table.Caption>List of available resources</Table.Caption>
        </Table>
    )
}

export default ResourceTable;