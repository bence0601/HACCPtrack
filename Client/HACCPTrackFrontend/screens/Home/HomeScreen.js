import { View, Text, Button } from "react-native";
import React from "react";
import { useAuth } from "../../Auth/AuthContext";

export default function HomeScreen({ navigate }) {
  const { email, role, logout } = useAuth();

  return (
    <View>
      <Text>HomeScreen</Text>
      {email ? (
        <Text>
          hello {email}! Role: {role}
        </Text>
      ) : (
        <Text>Login</Text>
      )}
      <Button title="Logout" onPress={() => logout()} />
    </View>
  );
}
