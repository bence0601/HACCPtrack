import { StatusBar } from "expo-status-bar";
import { StyleSheet, Text, View } from "react-native";
import CheckServerStatus from "./components/CheckServerStatus/CheckServerStatus";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import { NavigationContainer } from "@react-navigation/native";
import { useState } from "react";
import RegisterScreen from "./screens/AuthScreen/RegisterScreen";
import HomeScreen from "./screens/Home/HomeScreen";
import LoginScreen from "./screens/AuthScreen/LoginScreen";
import { useAuth } from "./Auth/AuthContext";
import AdminHomeScreen from "./screens/AdminScreens/AdminHomeScreen";

const Stack = createNativeStackNavigator();

export default function Navigation() {
  const { isSignedIn, role } = useAuth();
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="CheckServerStatus"
        screenOptions={{ headerShown: false }}
      >
        {isSignedIn ? (
          userRole === "admin" ? (
            <Stack.Screen name="AdminHome" component={AdminHomeScreen} />
          ) : (
            <Stack.Screen name="Home" component={HomeScreen} />
          )
        ) : (
          <>
            <Stack.Screen
              name="CheckServerStatus"
              component={CheckServerStatus}
            />
            <Stack.Screen name="Register" component={RegisterScreen} />
            <Stack.Screen name="Login" component={LoginScreen} />
          </>
        )}
      </Stack.Navigator>
    </NavigationContainer>
  );
}
