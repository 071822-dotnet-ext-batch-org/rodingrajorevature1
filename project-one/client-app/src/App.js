import { 
  ChakraProvider, 
  Center,
  Text,
  Box,
  Button
} from '@chakra-ui/react';

function App() {
  return (
    <ChakraProvider >
      <Center h='100vh'>
        <Text fontSize={40}>
            Hello, employees!
        </Text>
        <Box>
          <Button>
            Login as employee
          </Button>
          <Button>
            Login as manager
          </Button>
        </Box>
      </Center>
    </ChakraProvider>
  );
}

export default App;
