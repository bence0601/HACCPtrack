import { View, Text } from "react-native";
import React from "react";
import { useAuth } from "../../Auth/AuthContext";

export default function HomeScreen() {
  const { email } = useAuth();

  return (
    <View>
      <Text>HomeScreen</Text>
      {email ? <Text>hello {email}!</Text> : <Text>Login</Text>}
    </View>
  );
}
