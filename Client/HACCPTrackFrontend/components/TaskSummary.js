import React from "react";
import { View, Text, StyleSheet, Button } from "react-native";

const TaskSummary = () => {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Your daily task almost done!</Text>
      <View style={styles.progressCircle}>
        <Text style={styles.progressText}>95%</Text>
      </View>
      <Button title="View Task" onPress={() => {}} />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    backgroundColor: "#0D1B2A",
    padding: 16,
    borderRadius: 10,
    alignItems: "center",
  },
  title: {
    color: "white",
    marginBottom: 8,
  },
  progressCircle: {
    width: 50,
    height: 50,
    borderRadius: 25,
    borderWidth: 5,
    borderColor: "cyan",
    justifyContent: "center",
    alignItems: "center",
    marginBottom: 8,
  },
  progressText: {
    color: "white",
  },
});

export default TaskSummary;
