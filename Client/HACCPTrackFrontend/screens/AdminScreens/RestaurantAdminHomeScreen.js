import React from "react";
import { SafeAreaView, StyleSheet, ScrollView, Button } from "react-native";
import ProfileHeader from "../../components/Header/ProfileHeader";
import TaskSummary from "../../components/TaskSummary";
import TaskList from "../../components/TaskList";
import { useAuth } from "../../Auth/AuthContext";

export default function RestaurantAdminHomeScreen() {
  const { userName, logout } = useAuth();
  return (
    <SafeAreaView style={styles.container}>
      <ScrollView>
        <ProfileHeader userName={userName} />
        <TaskSummary />
        <TaskList />
        <Button title="Logout" onPress={() => logout()} />
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
