import { View, Text, Button } from "react-native";
import React from "react";
import { useAuth } from "../../Auth/AuthContext";

export default function RestaurantAdminHomeScreen() {
  const { logout } = useAuth();
  return (
    <View>
      <Text>This is RestaurantAdminHomeScreen</Text>
      <Button title="Logout" onPress={() => logout()} />
    </View>
  );
}
