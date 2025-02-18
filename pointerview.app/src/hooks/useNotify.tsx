import { showNotification } from "@mantine/notifications";
import { IconX, IconCheck } from '@tabler/icons-react';
import { Loader } from '@mantine/core';

export const useNotify = () => {
    return {
      success: (message: string) =>
        showNotification({
          title: "Success",
          message,
          color: "teal",
          icon: <IconCheck />,
          autoClose: 3000,
          withCloseButton: true
        }),
  
      error: (message: string) =>
        showNotification({
          title: "Error",
          message,
          color: "red",
          icon: <IconX />,
          autoClose: 3000,
          withCloseButton: true
        }),
  
      info: (message: string) =>
        showNotification({
          title: "Loading",
          message,
          color: "blue",
          icon: <Loader size={30} />,
          autoClose: 3000,
        }),
    };
  };