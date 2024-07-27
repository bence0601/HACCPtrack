import React from "react";
import { SafeAreaView, StyleSheet, ScrollView } from "react-native";
import ProfileHeader from "../../components/Header/ProfileHeader";
import TaskSummary from "../../components/TaskSummary";
import TaskList from "../../components/TaskList";
import { useAuth } from "../../Auth/AuthContext";

export default function RestaurantAdminHomeScreen() {
  const { logout } = useAuth();
  return (
    <SafeAreaView style={styles.container}>
      <ScrollView>
        <ProfileHeader />
        <TaskSummary />
        <TaskList />
      </ScrollView>
    </SafeAreaView>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#FFF",
  },
});
