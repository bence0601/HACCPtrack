import { StatusBar } from "expo-status-bar";
import { StyleSheet, Text, View } from "react-native";
import CheckServerStatus from "./components/CheckServerStatus/CheckServerStatus";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { NavigationContainer } from "@react-navigation/native";

const Stack = createNativeStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="CheckServerStatus"
        screenOptions={{ headerShown: false }}
      >
        <Stack.Screen name="CheckServerStatus" component={CheckServerStatus} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
