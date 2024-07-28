import { View, Text, StyleSheet } from "react-native";
import React from "react";
import { SafeAreaView } from "react-native-safe-area-context";
import ProfileHeader from "../../components/Header/ProfileHeader";

export default function RestaurantScreen() {
  return (
    <SafeAreaView style={styles.container}>
      <ProfileHeader title={"Edit Restaurant"} />
    </SafeAreaView>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#FFF",
  },
});
